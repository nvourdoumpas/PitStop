window.addEventListener('load', function () {
    setTimeout(function () {
        var description = document.getElementsByClassName("description")[0];
        //br = document.createElement('br');
        //info.appendChild(br);

        link = document.createElement('a');
        link.text = 'View PitStop API Documentation';
        link.target = '_blank';
        link.href = '../documentation';
        link.className = 'link';

        description.appendChild(link);
    }, 100)
})