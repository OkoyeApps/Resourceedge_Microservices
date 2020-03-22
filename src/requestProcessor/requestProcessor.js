import Axios from 'axios';

class requestProcessor {

    postRequest = (url) => {
        new Promise((resolve, reject) => {
            var accessToken = localStorage.getItem("token")
            Axios.post(`${url}`, {
                "headers": {
                    authorization: `Bearer ${accessToken}`,
                    'x-access-token': `${accessToken}`,
                    "Access-Control-Allow-Origin": "*",
                    "Content-Type": "application/json",
                },
            }).then(res => {
                console.log("reached", res)
            }).catch(error => {
            });
        })
    };

    postRequest2 = (url) => {
        return new Promise((resolve, reject) => {
            console.log("reached", url)
            Axios.post(`${url}`).then(res => {
                console.log("reached", url)
                resolve({ success: true })
            })
                .catch(error => {
                    reject({ success: false })
                });
        })
    };

    getRequest = (url) => {
        new Promise(() => {
            var accessToken = localStorage.getItem("token")
            Axios.get(`${url}`, {
                "headers": {
                    authorization: `Bearer ${accessToken}`,
                    'x-access-token': `${accessToken}`,
                    "Access-Control-Allow-Origin": "*",
                    "Content-Type": "application/json",
                },
            }).then(res => {
                console.log("reached", res)
            })
                .catch(error => {
                });
        })
    };

}

export default requestProcessor