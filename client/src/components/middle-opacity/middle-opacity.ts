import { roomSelector } from '../../store/room/room-selectors';
import { IRootState } from '../../store/types';
import MiddleOpacityView from './middle-opacity-view';
import {connect} from 'react-redux';

const mapStateToProps = (state: IRootState) => {
    const room = roomSelector(state);
    return {room};
};

export default connect(mapStateToProps)(MiddleOpacityView);
