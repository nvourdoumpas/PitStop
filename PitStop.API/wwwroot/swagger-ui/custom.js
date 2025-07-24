window.addEventListener('load', function () {
    setTimeout(function () {
        var description = document.getElementsByClassName("description")[0];
        //br = document.createElement('br');
        //info.appendChild(br);

        link = document.createElement('a');
        link.text = 'View PitStop Documentation';
        link.target = '_blank';
        link.href = '../redoc';
        link.className = 'link';

        description.appendChild(link);
    }, 100)
})