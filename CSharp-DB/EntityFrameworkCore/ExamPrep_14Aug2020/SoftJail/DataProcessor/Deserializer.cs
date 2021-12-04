namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ImportDepartmentDto[] departments = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            foreach (var departmentJson in departments)
            {
                if (!IsValid(departmentJson) || departmentJson.Cells.Length == 0 || !departmentJson.Cells.All(IsValid))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentJson.Name,
                    Cells = departmentJson.Cells.Select(x => new Cell
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    })
                    .ToList()
                };

                context.Departments.Add(department);
                output.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }
            context.SaveChanges();


            return output.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var prisonerMails = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            foreach (var prisonerJson in prisonerMails)
            {
                if (!IsValid(prisonerJson) || !prisonerJson.Mails.All(IsValid))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime.TryParseExact(prisonerJson.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
                var incarceranation = DateTime.ParseExact(prisonerJson.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                var prisoner = new Prisoner
                {
                    FullName = prisonerJson.FullName,
                    Nickname = prisonerJson.Nickname,
                    Age = prisonerJson.Age,
                    IncarcerationDate = incarceranation,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    Bail = prisonerJson.Bail,
                    CellId = prisonerJson.CellId,
                    Mails = prisonerJson.Mails.Select(m => new Mail
                    {
                        Sender = m.Sender, 
                        Address = m.Address,
                        Description = m.Description
                    }).ToArray()
                };

                context.Prisoners.Add(prisoner);
                output.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Officers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportOfficerDto[]), root);

            using StringReader strReader = new StringReader(xmlString);

            ImportOfficerDto[] deserializeOfficers = (ImportOfficerDto[])serializer.Deserialize(strReader);

            foreach (var officerDto in deserializeOfficers)
            {
                if (!IsValid(officerDto))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Money,
                    Position = Enum.Parse<Position>(officerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners.Select( x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToArray()
                };

                context.Officers.Add(officer);
                output.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}