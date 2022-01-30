function uppercase(text) {
    const regex = /\w+/g;
    let matchText = text.match(regex)

    if (matchText) {
        console.log(matchText.join(', ').toUpperCase());
    } else {
        return;
    }
}

