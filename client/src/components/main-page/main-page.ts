import {IPlayer, IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView from './main-page-view';
import {roomSelector} from '../../store/room/room-selectors';
import {userSelector} from '../../store/user/user-selectors';
import {getRoom} from '../../store/room/room-operations';
import {updateUser} from '../../store/user/user-operations';
import {voteByPlayerSelector} from '../../store/discussion/discussion-selectors';
import {updateVote as updateValueVote} from '../../store/discussion/discussion-operations';
import {Dispatch} from 'redux';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const player = userSelector(state);
  const vote = player && voteByPlayerSelector(state, player);
  return {
    room,
    vote,
    player,
    getVote: (user: IPlayer) => voteByPlayerSelector(state, user),
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    getRoom: async (roomHash: string) => {
      return dispatch(await getRoom(roomHash));
    },
    createUser: async (name: string | null) => {
      return dispatch(await updateUser(name));
    },
    updateVote: async (voteId: string, cardId: string) => {
      return dispatch(await updateValueVote(voteId, cardId));
    }
  };
};

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps, mapDispatchToProps))(MainPageView);
