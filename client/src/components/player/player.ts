import {compose} from 'redux';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MenuView from '../menu/menu-view';
import {IRootState, IVote} from '../../store/types';
import {voteArraySelector, voteSelector} from '../../store/discussion/discussion-selectors';
import * as React from 'react';
import {IUser} from './player-view';

const mapStateToProps = (state: IRootState) => {
  return {
    voteArray: voteArraySelector(state),
    getVote: (voteArray: {[p: string]: IVote | null}, playerId: string) => {
      return voteSelector(voteArray, playerId);
    },
  };
};

export default compose<React.FunctionComponent<IUser>>(withRouter, connect(mapStateToProps))(MenuView);
