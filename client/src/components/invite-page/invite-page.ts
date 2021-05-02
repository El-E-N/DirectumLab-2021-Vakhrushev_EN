import {compose, Dispatch} from 'redux';
import {removeUser, user, newUser} from '../../store/user/user-action-creators';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView from './invite-page-view';

const mapDispatchToProps = (dispatch: Dispatch) => {
  const addUser = (id: string, name: string) => {
    dispatch(user(id, name));
    dispatch(newUser(id, name));
  };

  return {
    removeUser: () => dispatch(removeUser()),
    addNewUser: (id: string, name: string) => addUser(id, name),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(InvitePageView);
