function colorize() {
    let rows = document.querySelectorAll('table tr:nth-child(2n)');
    
    rows.forEach(x => {
        x.style.background ='teal';
    });
}