import {compose, Dispatch} from 'redux';
import {removeUser, user} from '../../store/user/user-action-creators';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import InvitePageView, {IProps as IInvitePage} from './invite-page-view';
import {IRoom, IRootState, IUser} from '../../store/types';
import {roomByIdSelector} from '../../store/room/room-selectors';
import {addUser} from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState, ownProps: IInvitePage) => {
  const room = roomByIdSelector(state, ownProps.match.params.id);
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    removeUser: () => dispatch(removeUser()),
    addNewUser: (id: string, name: string) => dispatch(user(id, name)),
    addUserIntoRoom: (room: IRoom, newUser: IUser) => dispatch(addUser(room, newUser)),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(mapStateToProps, mapDispatchToProps))(InvitePageView);
