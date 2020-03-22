import requestProcessor from "../../requestProcessor/requestProcessor"
import Constants from '../constants/index'
const processor = new requestProcessor()

export const auth = () => dispatch => {
    new Promise((resolve, reject) => {
        processor.postRequest2(`post-me`).then((res) => {
                console.log(res)
            })
            .catch((err) => {
                console.log(err)
            })
        dispatch({
            type: Constants.AUTH,
            payload: 'result_of_simple_action'
        })
    })
}