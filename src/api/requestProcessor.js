import axios from 'axios';
// var baseUrl = "https://resourceedgeappraisalapi.azurewebsites.net/api";
var baseUrl = "http://localhost:5321/api"
var axiosClient = axios.create({
    baseURL : baseUrl, 
    headers: { "content-type": 'application/json', 'accept': 'application/json' }, timeout: 3000
});

const RequestProcessor = function (){
    this.Get = (url, accesstoken, callback) => {
        axiosClient.get(url, { auth: `Bearer ${accesstoken}` }).then(result => {
            console.log("result gotten", result)
            callback(true,  result.headers, result.status, result.data);
        }).catch(error => callback(false, error));
    };

    this.Post = (url, accesstoken, data, callback) => {
        axiosClient.post(url, data, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(true,result.headers, result.status, result.data);
        }).catch(error => callback(false,error));
    };
    this.Patch = (url, accesstoken, data, callback) => {
        axiosClient.patch(url, data, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(true, result.headers, result.status, result.data);
        }).catch(error => callback(false,error));
    };
    this.Delete = (url, accesstoken, data, callback) => {
        axiosClient.delete(url, { headers: { "x-access-token": accesstoken } }).then(result => {
            callback(true, result.headers, result.status, result.data);
        }).catch(error => callback(false,error));
    };
};

export default new RequestProcessor();