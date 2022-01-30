function fromJSONToHTMLTable(input) {
    let output = [];

    let inputAsArray = JSON.parse(input);

    output.push('<table>');
    let header = '   <tr>';

    for (let th in inputAsArray[0]) {
        let thead = escapeSpecialCharacters(th);
        header += `<th>${thead}</th>`
    }

    header += '</tr>';
    output.push(header);

    for (let info of inputAsArray) {
        let row = '';
        row += '   <tr>';

        for (const key in info) {
            let item = escapeSpecialCharacters(info[key])
            row += `<td>${item}</td>`;

        }

        row += '</tr>'
        output.push(row);
    }

    output.push(('</table>'));
    output.forEach(x => console.log(x));

    function escapeSpecialCharacters(input) {
        return input.toString()
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/\>/g, '&gt;')
            .replace(/\</g, '&lt;')
            .replace(/'/g, '&#39;');
    }
}

fromJSONToHTMLTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`);