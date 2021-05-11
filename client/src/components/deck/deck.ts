import {connect} from 'react-redux';
import {IRootState} from '../../store/types';
import DeckView from './deck-view';
import {roomSelector} from '../../store/room/room-selectors';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  return {
    room,
  };
};

export default connect(mapStateToProps)(DeckView);
