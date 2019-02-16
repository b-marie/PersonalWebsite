const requestAdminDetails = 'REQUEST_ADMIN_DETAILS';
const receiveAdminDetails = 'RECEIVE_ADMIN_DETAILS';
const initialState = { adminDetails: [], isLoading: false };

export const actionCreators = {
    requestAdminDetails: () => async (dispatch, getState) => {
        //if (getState().adminDetails != null) {
        //    // Don't issue a duplicate request (we already have or are loading the requested data)
        //    return;
        //}

        dispatch({ type: requestAdminDetails });

        const url = `api/Admin`;
        const response = await fetch(url);
        const adminDetails = await response.json();

        dispatch({ type: receiveAdminDetails, adminDetails });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestAdminDetails) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === receiveAdminDetails) {
        return {
            ...state,
            adminDetails: action.adminDetails,
            isLoading: false
        };
    }

    return state;
};
