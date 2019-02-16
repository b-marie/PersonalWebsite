import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/Admin';

class Admin extends Component {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestAdminDetails();
    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        this.props.requestAdminDetails();
    }

    render() {
        return (
            <div>
                <h1>Admin</h1>
                {renderAdminTable(this.props)}
            </div>
        );
    }
}


function renderAdminTable(props) {
    return (
        <div>
            <form>
                {props.adminDetails.map(admin => 
                    <div>
                        <input type="text" placeholder={admin.firstName}/>
                        <input type="text" placeholder={admin.lastName}/> 
                    </div>
                 )}
            </form>
        </div>
    );
}

//function renderForecastsTable(props) {
//    return (
//        <table className='table'>
//            <thead>
//                <tr>
//                    <th>Date</th>
//                    <th>Temp. (C)</th>
//                    <th>Temp. (F)</th>
//                    <th>Summary</th>
//                </tr>
//            </thead>
//            <tbody>
//                {props.forecasts.map(forecast =>
//                    <tr key={forecast.dateFormatted}>
//                        <td>{forecast.dateFormatted}</td>
//                        <td>{forecast.temperatureC}</td>
//                        <td>{forecast.temperatureF}</td>
//                        <td>{forecast.summary}</td>
//                    </tr>
//                )}
//            </tbody>
//        </table>
//    );
//}

//function renderPagination(props) {
//    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
//    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

//    return <p className='clearfix text-center'>
//        <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
//        <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
//        {props.isLoading ? <span>Loading...</span> : []}
//    </p>;
//}

export default connect(
    state => state.adminDetails,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Admin);
