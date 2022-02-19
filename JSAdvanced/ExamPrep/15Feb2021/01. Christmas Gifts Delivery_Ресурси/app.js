function solution() {
    let newGiftElement = document.querySelector("input[type='text']");
    let addGiftButton = document.getElementsByTagName('button')[0];

    addGiftButton.addEventListener('click', function() {
        
        let listOfGigts = document.querySelector(".container section:nth-child(2) ul");
        let liElement = document.createElement('li');
        liElement.classList.add('gift');
        liElement.textContent = newGiftElement.value;

        let sendElement = document.createElement('button');
        sendElement.textContent = 'Send';
        sendElement.id = 'sendButton';
        
        let discardElement = document.createElement('button');
        discardElement.textContent = 'Discard';
        discardElement.id = 'discarButton';

        liElement.appendChild(sendElement);
        liElement.appendChild(discardElement);

        listOfGigts.appendChild(liElement);

        Array.from(listOfGigts.querySelectorAll('li'))
        .sort((a, b) => a.textContent.localeCompare(b.textContent))
        .forEach(li => listOfGigts.appendChild(li));
    
        newGiftElement.value = '';

        sendElement.addEventListener('click', function() {
            let sentGifts = document.querySelector(".container section:nth-child(3) ul");
            sentGifts.appendChild(liElement);
            sendElement.remove();
            discardElement.remove();
        })

        discardElement.addEventListener('click', function() {
            let discardedGifts = document.querySelector(".container section:nth-child(4) ul");
            discardedGifts.appendChild(liElement);
            sendElement.remove();
            discardElement.remove();

        })
    })
   
}