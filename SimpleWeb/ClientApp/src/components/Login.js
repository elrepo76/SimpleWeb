import React, { Fragment, useState } from 'react';

const Login = () => {
    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const handleUserNameChange = (value) => {
        setUserName(value);
    };

    const handlePasswordChange = (value) => {
        setPassword(value);
    };

    const handleLogin = () => {
        const userlogin = {
            Username: username,
            Password: password
        }

        const req = {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(userlogin)
        };

        fetch(`login`, req)
            .then(response => response.text())
            .then(data => alert(data))
            .catch(error => alert(error))

        /*
        axios.post(url, JSON.stringify(userlogin))
        .then((result) => {
            alert(result.data);
        }).catch((error) => {
            alert(error);
        })
        */
    }

    return (
        <Fragment>
            <div>
                <br></br><label class="form-label">Enter credentials</label>
            </div>
            <div class="row g-2">
                <div class="col-sm">
                    <input type="text" id="txtUserName" class="form-control" placeholder='Username' onChange={(e) => handleUserNameChange(e.target.value)} /><br></br>
                </div>
                <div class="col-sm">
                    <input type="password" id="txtPassword" class="form-control" placeholder='Password' onChange={(e) => handlePasswordChange(e.target.value)} /><br></br>
                </div>
            </div>
            <button type="submit" class="btn btn-primary mb-3" onClick={() => handleLogin()}> Login </button>
        </Fragment>
    )
}
export default Login;