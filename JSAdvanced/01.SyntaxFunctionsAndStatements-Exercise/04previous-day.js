function previousDay(year, month, day) {
    let dateFormat = `${year}-${month}-${day}`
    let date = new Date(dateFormat);

    date.setDate(date.getDate() - 1);
    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

