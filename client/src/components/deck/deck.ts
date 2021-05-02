import {Dispatch} from 'redux';
import {connect} from 'react-redux';
import {vote} from '../../store/room/room-action-creators';
import {IRootState} from '../../store/types';
import {IMatchParams} from '../main-page/main-page-view';
import DeckView from './deck-view';

const mapStateToProps = (state: IRootState, ownProps: IMatchParams) => {
  const room = state.rooms.find((r) => r.id === ownProps.id)!;
  return {
    room,
  };
};

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    vote: (roomId: string, value: string) => dispatch(vote(roomId, value)),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DeckView);
