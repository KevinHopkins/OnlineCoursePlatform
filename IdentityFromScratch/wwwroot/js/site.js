// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
    const otpInputs = document.querySelectorAll('.otp-box');

    otpInputs[0].addEventListener('paste', handlePaste);

    function handlePaste(e) {
        const pasteData = e.clipboardData.getData('text');

        // Validate if the pasted data is exactly 6 digits and numeric
        if (pasteData.length === 6 && !isNaN(pasteData)) {
            // Split the data into individual digits and fill the OTP boxes
            otpInputs.forEach((input, index) => {
                input.value = pasteData[index] || '';  // Assign each character to the respective input
            });
        } else {
            alert('Please paste exactly 6 numeric digits.');
        }

        e.preventDefault();  // Prevent default pasting behavior
    }
});


const inputs = document.querySelectorAll('.otp-box');

inputs.forEach((input, index) => {
    input.addEventListener('input', (e) => {
        if (e.target.value.length === 1 && index < inputs.length - 1) {
            inputs[index + 1].focus();
        }
    });

    input.addEventListener('keydown', (e) => {
        if (e.key === 'Backspace' && input.value.length === 0 && index > 0) {
            inputs[index - 1].focus();
        }
    });
});