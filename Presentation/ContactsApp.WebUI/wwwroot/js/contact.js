window.addEventListener('load', async (e) => {
    await AddContact();
    await UpdateContact();
    await UpdateContactFeature();
    PhoneNumberMask();
});
async function AddContact() {
    const contactForm = document.getElementById('contact-form');

    if (!contactForm) return;

    contactForm?.addEventListener('submit', async (form) => {

        form.preventDefault();

        const isValid = formValidation(form);

        if (isValid == false) return;

        let data = formSerialize(contactForm);

        console.log(data);

        await postAsJsonAsyncWithToken(form.target.action, data, 'application/x-www-form-urlencoded')
            .then((res) => {
                if (res.success)
                    location.reload();
                else
                    alert(res.message);
            })
            .catch((error) => {
                console.error('Hata:', error);
            });
    });
}

async function UpdateContact() {
    const updateContactForm = document.getElementById('update-contact-form');

    if (!updateContactForm) return;

    updateContactForm?.addEventListener('submit', async (form) => {

        form.preventDefault();

        const isValid = formValidation(form);

        if (isValid == false) return;

        let data = formSerialize(updateContactForm);

        console.log(data);

        await postAsJsonAsyncWithToken(form.target.action, data, 'application/x-www-form-urlencoded')
            .then((res) => {
                if (res.success)
                    location.reload();
                else
                    alert(res.message);
            })
            .catch((error) => {
                console.error('Hata:', error);
            });
    });
}

async function UpdateContactFeature() {
    const updateContactForm = document.getElementById('update-contact-feature-form');

    if (!updateContactForm) return;

    updateContactForm?.addEventListener('submit', async (form) => {

        form.preventDefault();

        const isValid = formValidation(form);

        if (isValid == false) return;

        let data = formSerialize(updateContactForm);

        console.log(data);

        await postAsJsonAsyncWithToken(form.target.action, data, 'application/x-www-form-urlencoded')
            .then((res) => {
                if (res.success)
                    location.reload();
                else
                    alert(res.message);
            })
            .catch((error) => {
                console.error('Hata:', error);
            });
    });
}

async function DeleteContact(el) {
    if (!el) return;

    const id = el?.dataset?.id,
    url = `/contact/delete-contact`;

    if (!id) return;

    await postAsJsonAsync(url, JSON.stringify(id))
        .then((res) => {
            if (res.success)
                location.reload();
            else
                alert(res.message);
        })
        .catch((error) => {
            console.error('Hata:', error);
        });
}

const PhoneNumberMask = () => {
    Array.from(document.querySelectorAll('.phone-number')).every(el => {
        vanillaTextMask.maskInput({
            inputElement: el,
            mask: [0, ' ', '(', /\d/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, ' ', /\d/, /\d/, /\d/, /\d/]
        });
    });
}

async function NewContactReport() {
    await getAsJsonAsync('/contact/generate-contact-report')
        .then((res) => {
            if (res.success)
                location.reload();
            else
                alert(res.message);
        })
        .catch((error) => {
            console.error('Hata:', error);
        });
}
