function extractText() {
   let nodeElements = document.querySelectorAll('ul#items li');
   let textArea = document.querySelector('#result');

   for (const node of nodeElements) {
       textArea.value += node.textContent + '\n';
   }
}