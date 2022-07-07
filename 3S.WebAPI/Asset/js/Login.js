

let password = $('#normal_login_password')
let email = $('#normal_login_email')
let btnLogin = $(".login-form-button")

btnLogin.click(() => {
    console.log(
        "email: " + email.val()
    )
    console.log(
        "pass: " + password.val()
    )
})

window.axios.defaults.baseURL = "https://store--users.herokuapp.com/api/"
window.axios.defaults.headers.common['X-Requested-With'] = 'XMLHttpRequest';
 const getUsers = () => {
    axios.get('users')
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
}
getUsers()