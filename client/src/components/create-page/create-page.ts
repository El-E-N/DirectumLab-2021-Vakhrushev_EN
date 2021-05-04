import {compose, Dispatch} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import CreatePageView from './create-page-view';
import {room} from '../../store/room/room-action-creators';
import {removeUser, user} from '../../store/user/user-action-creators';
import {IUser} from '../../store/types';

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    createRoom: (roomId: string, name: string, cards: Array<string>, selectedCard: string | null, owner: IUser, storyId: string) =>
      dispatch(room(roomId, name, cards, selectedCard, owner, storyId)),
    createUser: (id: string, name: string) => dispatch(user(id, name)),
    removeUser: () => dispatch(removeUser()),
  };
};

export default compose<React.ComponentClass>(withRouter, connect(null, mapDispatchToProps))(CreatePageView);
