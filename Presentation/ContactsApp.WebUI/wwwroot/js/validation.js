function formValidation(form) {
    if (!form) return;

    const requiredFields = Array.from(form.target).filter(field => {
        return field.dataset.validation === "true";
    });

    let results = [];

    requiredFields?.forEach((element) => {

        if (element?.dataset?.type == 'email')
            results.push(validateEmail(element));
        else if (element?.dataset?.type == 'phone')
            results.push(validatePhoneNumber(element));
        else
            results.push(validateNullCheck(element));
    });

    if (results.includes(false) == true)
        return false;

    return true;
}

function validateEmail(el) {

    const pattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
        value = el?.value.trim()

    let isValid = true;

    if (!value) return isValid;

    isValid = validatePatternCheck(el, value, pattern);

    return isValid;
}
function validatePhoneNumber(el) {
    const pattern = /^[0-9]+$/;
    value = el?.value.trim();

    let isValid = true;

    if (!value) return isValid;

    value = generatePhoneNumber(value);
    isValid = validatePatternCheck(el, value, pattern);

    return isValid;
}
function validateNullCheck(el) {
    if (!el) return;

    const maxLength = el?.getAttribute('max') ?? 0,
        minLength = el?.getAttribute('min') ?? 0,
        errMsg = el?.closest('.form-group').querySelector('.err-valid-msg'),
        value = el?.value.trim();

    if (!value || value?.length <= 0) {
        errMsg.innerText = errMsg?.dataset?.message;
        removeHiddenClass(errMsg);
        return false;
    }
    else if (value?.length > maxLength && maxLength != 0) {

        errMsg.innerText = `Girilen veri maksimum ${maxLength} karakter olmalıdır`;
        removeHiddenClass(errMsg);

        return false;
    }
    else if (value?.length < minLength && minLength != 0) {
        errMsg.innerText = `Girilen veri minimum ${minLength} karakter olmalıdır`;
        removeHiddenClass(errMsg);
        return false;
    }
    addHiddenClass(errMsg);

    return true;
}
function validatePatternCheck(el, value, pattern) {

    if (!value) return false;

    const errMsg = el?.closest('.form-group').querySelector('.err-valid-msg');

    if (pattern.test(value) == false) {
        errMsg.innerText = errMsg?.dataset?.message;
        removeHiddenClass(errMsg)
        return false;
    }

    addHiddenClass(errMsg);
    return true;
}

function removeHiddenClass(el) {
    if (!el) return;
    el?.classList.remove('d-none');
}
function addHiddenClass(el) {
    if (!el) return;
    el?.classList.add('d-none');
}

function generatePhoneNumber(phoneNumber) {
    phoneNumber = phoneNumber.replace(/[() ]/g, "");;
    phoneNumber = phoneNumber.slice(-10);

    return phoneNumber;
}
