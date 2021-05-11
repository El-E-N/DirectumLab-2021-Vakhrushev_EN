import {Dispatch} from 'redux';
import {updateVote as updateValueVote} from '../../store/discussion/discussion-operations';
import {connect} from 'react-redux';
import CardView from './card-view';
import {voteArraySelector, voteSelector} from '../../store/discussion/discussion-selectors';
import {ICard, IRoom, IRootState} from '../../store/types';
import {userSelector} from '../../store/user/user-selectors';
import {roomSelector} from '../../store/room/room-selectors';
import {updateSelectedCard} from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState) => {
  const voteArray = voteArraySelector(state);
  const player = userSelector(state);
  const vote = voteArray && player && voteSelector(voteArray, player.id);
  return {
    vote,
    room: roomSelector(state)
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    updateVote: async (voteId: string, cardId: string) => {
      return dispatch(await updateValueVote(voteId, cardId));
    },
    updateCard: (room: IRoom, selectedCard: ICard) => {
      dispatch(updateSelectedCard(room, selectedCard));
    }
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(CardView);
