function solve(){
   
   const createButtonElement = document.querySelector('.btn.create');

   createButtonElement.addEventListener('click', function(e) {
      e.preventDefault();
      const authorInputElement = document.getElementById('creator');
      const titleInputElement = document.getElementById('title');
      const categoryInputElement = document.getElementById('category');
      const contentInputElement = document.getElementById('content');

      const articleElement = document.createElement('article');

      const titleElement = document.createElement('h1');
      titleElement.textContent = titleInputElement.value;
      articleElement.appendChild(titleElement);

      const categoryElement = document.createElement('p');
      categoryElement.textContent = 'Category: ';

      const categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInputElement.value;
      categoryElement.appendChild(categoryStrong);
      articleElement.appendChild(categoryElement);

      const creatorElement = document.createElement('p');
      creatorElement.textContent = 'Creator: '
      const creatorStrongElement = document.createElement('strong');
      creatorStrongElement.textContent = authorInputElement.value;
      creatorElement.appendChild(creatorStrongElement);
      articleElement.appendChild(creatorElement);

      const contentElement = document.createElement('p');
      contentElement.textContent = contentInputElement.value;
      articleElement.appendChild(contentElement);

      const divBtnElement = document.createElement('div');
      divBtnElement.classList.add('buttons');
      const btnElement = document.createElement('button');
      btnElement.classList.add('btn', 'delete');
      btnElement.textContent = 'Delete';
      
      const archiveElement = document.createElement('button');
      archiveElement.textContent = 'Archive';
      archiveElement.classList.add('btn', 'archive');
      divBtnElement.appendChild(btnElement);
      divBtnElement.appendChild(archiveElement);
      articleElement.appendChild(divBtnElement);

      const divElement = document.querySelector('.site-content main section');
      divElement.appendChild(articleElement);

      authorInputElement.value = '';
      titleInputElement.value = '';
      categoryInputElement.value = '';
      contentInputElement.value = '';

      archiveElement.addEventListener('click', function() {
         const archiveSection = document.querySelector('.archive-section ol');
         const liElement = document.createElement('li');
         liElement.textContent = titleElement.textContent;

         archiveSection.appendChild(liElement);

         Array.from(archiveSection.querySelectorAll('li'))
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => archiveSection.appendChild(li));
         articleElement.remove();
      });

      
      btnElement.addEventListener('click', function() {
         articleElement.remove();
      });
   });

}
