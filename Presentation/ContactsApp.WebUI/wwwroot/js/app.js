
async function baseRequestAsJsonAsyncWithToken(url, data, method = 'POST', contentType = 'application/json') {
    try {

        const antiForgeryToken = document.querySelector('input[name="__RequestVerificationToken"]').value;

        var response = await fetch(url, {
            method: method,
            headers: {
                'Content-Type': contentType,
                'RequestVerificationToken': antiForgeryToken
            },
            body: data
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const responseData = await response.text();
        return JSON.parse(responseData);
    } catch (error) {
        console.error('POST isteği başarısız oldu:', error);
    }
}

async function baseRequestAsJsonAsync(url, data, method = 'POST', contentType = 'application/json') {
    try {

        var response = await fetch(url, {
            method: method,
            headers: {
                'Content-Type': contentType
            },
            body: data
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const responseData = await response.text();
        return JSON.parse(responseData);
    } catch (error) {
        console.error('POST isteği başarısız oldu:', error);
    }
}
async function getAsync(url) {
    try {
        var response = await fetch(url, {
            method: 'GET'
        });

        const responseData = await response.text();

        return responseData;

    } catch (error) {
        console.error('POST isteği başarısız oldu:', error);
    }
}

async function getAsJsonAsync(url) {
    try {
        var response = await fetch(url, {
            method: 'GET'
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const responseData = await response.text();

        return JSON.parse(responseData);
    } catch (error) {
        console.error('POST isteği başarısız oldu:', error);
    }
}

function formSerializeAsJson(form) {

    if (!form || form === '') return;

    const formData = new FormData(form);
    let serializedData = {};

    formData.forEach((value, key) => {
        serializedData[key] = value;
    });

    return JSON.stringify(serializedData);
}

function formSerialize(form) {
    const formData = new FormData(form);
    const serializedData = [];

    formData.forEach((value, key) => {
        serializedData.push(encodeURIComponent(key) + '=' + encodeURIComponent(value));
    });

    return serializedData.join('&');
}

function showSuccessMessage(el, message) {

    if (!el) return;

    el.classList.remove('hidden');
    el.classList.remove('text-red-600');
    el.classList.add('text-green-600');
    el.innerText = message;
}
function errorSuccessMessage(el, message) {

    if (!el) return;

    el.classList.remove('hidden');
    el.classList.add('text-red-600');
    el.classList.remove('text-green-600');
    el.innerText = message;
}