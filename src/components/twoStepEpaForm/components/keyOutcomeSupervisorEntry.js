import React, { useState, useEffect } from 'react'
import Selector from '../../selectiveSearch/selectiveSearch';
import { connect } from 'react-redux'
import { SearchForSupervisors } from '../../../reduxStore/actions/EpaActions';
import { UpdateKRA_Supervisors } from '../../../reduxStore/actions/krAction'

function KeyOutcomeSupervisorEntry(props) {

    var [searchResult, setSearchResult] = useState([])
    var [searchValue, setSearchValue] = useState('')
    var [domfunc, setDomFunc] = useState({jQuery : null, select2 : null});
    useEffect(() => {
        var $ = window.$;
        var select2 = window.select2;
        if($ && select2){
            console.log("dom fucntions",  $('#select1'))
        //    $('#select1').select2({})    
        //    console.log()
        }
    },[]);
    var jQuery = window.$;
var select2 = window.select2;


    const searchSupervisor = async () => {
        if (searchValue.trim() !== '') {
            await props.SearchForSupervisors(searchValue, (success, data) => {
                setSearchResult(data)
                console.log("result from search", data)
            })
        }

    }
    var {temp} = props;
  
    return (
        <div>
            <article className="pt-3">
                <div className="row">
                    <div className="col-6">
                        <label className="form-label kra-sm-text">Appraiser</label>
                            {/* <select className="form-control" id="select1">
                                <option>First option</option>
                            </select> */}
                        <Selector result={searchResult} setValue={setSearchValue} isSearchable={true} searchClass={"form-control"} disableInput={temp ? false : true} searchOnChange={searchSupervisor} currentActive={props.currentActive} UpdateKRA={props.UpdateKRA_Supervisors} supervisorStat="appraiser" />
                    </div>
                    <div className="col-6">
                        <label className="form-label kra-sm-text">Head of Department</label>
                        <Selector result={searchResult} setValue={setSearchValue} isSearchable={true} searchClass={"form-control"} disableInput={temp ? false : true} searchOnChange={searchSupervisor} currentActive={props.currentActive} UpdateKRA={props.UpdateKRA_Supervisors} supervisorStat="headofdepartment" />
                    </div>
                </div>
            </article>
        </div>
    )
}

export default connect(null, { SearchForSupervisors, UpdateKRA_Supervisors })(KeyOutcomeSupervisorEntry)
