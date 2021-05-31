import { IRootState } from '../../store/types';
import { connect } from 'react-redux';
import { roomSelector } from '../../store/room/room-selectors';
import ModalView from './modal-view';
import { discussionByIdSelector, discussionsSelector, voteArraySelector } from '../../store/discussions/discussions-selectors';
import {Dispatch} from 'redux';
import { changeShownModal } from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState) => {
    const room = roomSelector(state);
    const discussions = discussionsSelector(state);

    const discussion = (room && room.choosedDiscussionId && discussions) ?
                        discussionByIdSelector(room.choosedDiscussionId, discussions) :
                        null;
    return {
        room,
        discussion
    };
}

const mapDispatchToProps = (dispatch: Dispatch) => {
    return {
        closeModal: () => {
            return dispatch(changeShownModal(false));
        },
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ModalView);
