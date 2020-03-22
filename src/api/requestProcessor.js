import axios from 'axios';
var baseUrl = "http://localhost:6000/api";
var axiosClient = axios.create({
    baseURL = baseUrl, responseType: 'document',
    withCredentials: true,
    headers: { "content-type": 'application/json', 'accept': 'application/json' }, timeout: 3000
});

const RequestProcessor = function (){
    this.Get = (url, accesstoken, callback) => {
        axiosClient.get(url, { auth: `Bearer ${accesstoken}` }).then(result => {
            callback(result.headers, result.status, result.data);
        }).catch(error => callback(error));
    };

    this.Post = (url, accesstoken, data, callback) => {
        axiosClient.post(url, data, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(result.headers, result.status, result.data);
        }).catch(error => callback(error));
    };
    this.Patch = (url, accesstoken, data, callback) => {
        axiosClient.patch(url, data, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(result.headers, result.status, result.data);
        }).catch(error => callback(error));
    };
    this.Delete = (url, accesstoken, data, callback) => {
        axiosClient.delete(url, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(result.headers, result.status, result.data);
        }).catch(error => callback(error));
    };
};

export default new RequestProcessor();