import {Dispatch} from 'redux';
import {connect} from 'react-redux';
import {updateVote as updateValueVote} from '../../store/discussion/discussion-action-creators';
import {ICard, IRootState} from '../../store/types';
import DeckView from './deck-view';
import {roomSelector} from '../../store/room/room-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateVote: async (voteId: string, card: ICard) => {
      return dispatch(await updateValueVote(voteId, card));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DeckView);
