


const page1 = document.getElementById('page1');
const page2 = document.getElementById('page2');

const page1Button = document.getElementById('page1Button');
const page2Button = document.getElementById('page2Button');
const nextButton = document.getElementById('nextButton');

page1Button.addEventListener('click', function () {
    page1.style.display = 'block';
    page2.style.display = 'none';
});

page2Button.addEventListener('click', function () {
    page1.style.display = 'none';
    page2.style.display = 'block';
});

nextButton.addEventListener('click', function () {
    if (page1.style.display === 'block') {
        page1.style.display = 'none';
        page2.style.display = 'block';
    } else {
        page1.style.display = 'block';
        page2.style.display = 'none';
    }
});
