window.addEventListener('load', solve);

function solve() {
    const genreInputElement = document.getElementById('genre');
    const nameInputElement = document.getElementById('name');
    const authorInputElement = document.getElementById('author');
    const dateInputElement = document.getElementById('date');
    const addButton = document.getElementById('add-btn');
    let likes = 0;
    
    let allhitsElementDiv = document.querySelector('.all-hits-container');

    addButton.addEventListener('click', function (e) {
        e.preventDefault();

     if(genreInputElement.value && nameInputElement.value && authorInputElement.value && dateInputElement.value) {
         let divElement = document.createElement('div');
         divElement.classList.add('hits-info');

         let imageElement = document.createElement('img');
         const attr = document.createAttribute('src');
         attr.value = './static/img/img.png';
         imageElement.setAttributeNode(attr);
         divElement.appendChild(imageElement);

         let genreElement = document.createElement('h2');
         genreElement.textContent = `Genre: ${genreInputElement.value}`;
         let nameElement = document.createElement('h2');
         nameElement.textContent = `Name: ${nameInputElement.value}`;
         let authorElement = document.createElement('h2');
         authorElement.textContent = `Author: ${authorInputElement.value}`;
         let dateElement = document.createElement('h3');
         dateElement.textContent = `Date: ${dateInputElement.value}`;

         let saveButton = document.createElement('button');
         saveButton.classList.add('save-btn');
         saveButton.textContent = 'Save song';

         let likeButton = document.createElement('button');
         likeButton.classList.add('like-btn');
         likeButton.textContent = 'Like song';

         let deleteButton = document.createElement('button');
         deleteButton.classList.add('delete-btn');
         deleteButton.textContent = 'Delete';

         divElement.appendChild(genreElement);
         divElement.appendChild(nameElement);
         divElement.appendChild(authorElement);
         divElement.appendChild(dateElement);
         divElement.appendChild(saveButton);
         divElement.appendChild(likeButton);
         divElement.appendChild(deleteButton);

         allhitsElementDiv.appendChild(divElement);

         genreInputElement.value = '';
         nameInputElement.value = '';
         authorInputElement.value = '';
         dateInputElement.value = '';
        

         likeButton.addEventListener('click', function () {
             let totalLikes = document.querySelector('.likes p');
             likes++;
             totalLikes.textContent = `Total Likes: ${likes}`;
             likeButton.disabled = true;
         });

         saveButton.addEventListener('click', function () {
            
            let divContainerElement = document.getElementsByClassName('saved-container')[0];
            saveButton.remove();
            likeButton.remove();
            divContainerElement.appendChild(divElement);
         });

         deleteButton.addEventListener('click', function() {
            divElement.remove();
         });

     }
     
    });
}