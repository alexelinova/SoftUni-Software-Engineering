window.addEventListener('load', solution);

function solution() {
  const fullNameInputElemet = document.getElementById('fname');
  const emailInputElement = document.getElementById('email');
  const phoneInputElement = document.getElementById('phone');
  const addressInputElement = document.getElementById('address');
  const postalCodeInputElement = document.getElementById('code');

  const submitButton = document.getElementById('submitBTN');
  const editButton = document.getElementById('editBTN');
  const continueButton = document.getElementById('continueBTN')


  submitButton.addEventListener('click', function () {

    const ulInfoPreviewElement = document.getElementById('infoPreview');

    if (!fullNameInputElemet.value || !emailInputElement.value) {
      return;
    }

    const liFullNameElement = document.createElement('li');
    liFullNameElement.textContent = `Full Name: ${fullNameInputElemet.value}`;
    const liEmailElement = document.createElement('li');
    liEmailElement.textContent = `Email: ${emailInputElement.value}`;

    ulInfoPreviewElement.appendChild(liFullNameElement);
    ulInfoPreviewElement.appendChild(liEmailElement);

    const liPhoneElement = document.createElement('li');
    liPhoneElement.textContent = `Phone Number: ${phoneInputElement.value}`;
    ulInfoPreviewElement.appendChild(liPhoneElement);

    const liAddressElement = document.createElement('li');
    liAddressElement.textContent = `Address: ${addressInputElement.value}`;
    ulInfoPreviewElement.appendChild(liAddressElement);

    const liPostalElement = document.createElement('li');
    liPostalElement.textContent = `Postal Code: ${postalCodeInputElement.value}`;
    ulInfoPreviewElement.appendChild(liPostalElement);


    fullNameInputElemet.value = '';
    emailInputElement.value = '';
    phoneInputElement.value = '';
    addressInputElement.value = '';
    postalCodeInputElement.value = '';


    submitButton.disabled = true;
    editButton.disabled = false;
    continueButton.disabled = false;

    editButton.addEventListener('click', function () {

      fullNameInputElemet.value = liFullNameElement.textContent.split(': ')[1];
      emailInputElement.value = liEmailElement.textContent.split(': ')[1];
      phoneInputElement.value = liPhoneElement.textContent.split(': ')[1];
      addressInputElement.value = liAddressElement.textContent.split(': ')[1];
      postalCodeInputElement.value = liPostalElement.textContent.split(': ')[1];

      ulInfoPreviewElement.textContent = '';

      editButton.disabled = true;
      continueButton.disabled = true;
      submitButton.disabled = false;
    });

    continueButton.addEventListener('click', function () {
      const blockElement = document.getElementById('block');
      blockElement.textContent = '';

      const h3Element = document.createElement('h3');
      h3Element.textContent = 'Thank you for your reservation!';
      blockElement.appendChild(h3Element);
    })

  });

}
