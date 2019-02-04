const requestAdminDetails = 'REQUEST_ADMIN_DETAILS';
const receiveAdminDetails = 'RECEIVE_ADMIN_DETAILS';
const initialState = { adminDetails: [], isLoading: false };

export const actionCreators = {
    requestAdminDetails: startDateIndex => async (dispatch, getState) => {
        if (startDateIndex === getState().weatherForecasts.startDateIndex) {
            // Don't issue a duplicate request (we already have or are loading the requested data)
            return;
        }

        dispatch({ type: requestAdminDetails, startDateIndex });

        const url = `api/Admin`;
        const response = await fetch(url);
        const adminDetails = await response.json();

        dispatch({ type: receiveAdminDetails, startDateIndex, adminDetails });
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
            adminDetails: action.forecasts,
            isLoading: false
        };
    }

    return state;
};
