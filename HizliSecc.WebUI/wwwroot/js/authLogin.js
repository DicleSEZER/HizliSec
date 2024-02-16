function goster(formAdı) {
    var saklaForm = document.getElementById('sakla');
    var müsteriKayıtForm = document.getElementById('müsteri-kayıt-form');
    var saticiKayıtForm = document.getElementById('satici-kayıt-form');
    var müsterigirişForm = document.getElementById('müsteri-giriş-form');
    var saticigirisForm = document.getElementById('satici-giris-form');

    if (formAdı === 'satıcı-kayıt') {
        saticiKayıtForm.style.display = 'block'
        müsteriKayıtForm.style.display = 'none';
        müsterigirişForm.style.display = 'none';
        saticigirisForm.style.display = 'none';
    }
    else if (formAdı === 'müşteri-kayıt') {
        müsteriKayıtForm.style.display = 'block';
        saticigirisForm.style.display = 'none';
        müsterigirişForm.style.display = 'none';
        saticiKayıtForm.style.display = 'none';

    }
    else if (formAdı === 'satıcı-giriş') {
        müsteriKayıtForm.style.display = 'none';
        saticigirisForm.style.display = 'block';
        müsterigirişForm.style.display = 'none';
        saticiKayıtForm.style.display = 'none';

    }
    else if (formAdı === 'müşteri-giriş') {
        müsteriKayıtForm.style.display = 'none';
        saticigirisForm.style.display = 'none';
        müsterigirişForm.style.display = 'block';
        saticiKayıtForm.style.display = 'none';

    }
    else if (formAdı === 'sakla') {
        müsteriKayıtForm.style.display = 'none';
        saticigirisForm.style.display = 'none';
        müsterigirişForm.style.display = 'none';
        saticiKayıtForm.style.display = 'none';

    }



}
