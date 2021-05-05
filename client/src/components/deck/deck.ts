import {Dispatch} from 'redux';
import {connect} from 'react-redux';
import {updateVote as updateValueVote} from '../../store/room/room-action-creators';
import {IRootState} from '../../store/types';
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
    updateVote: (roomId: string, value: string) => dispatch(updateValueVote(roomId, value)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DeckView);
