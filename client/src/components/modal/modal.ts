import {IRootState} from '../../store/types';
import {connect} from 'react-redux';
import {roomSelector} from '../../store/room/room-selectors';
import ModalView from './modal-view';
import {discussionByIdSelector, discussionsSelector} from '../../store/discussions/discussions-selectors';
import {Dispatch} from 'redux';
import {changeChoosedDiscussion} from '../../store/room/room-action-creators';

const mapStateToProps = (state: IRootState) => {
  const room = roomSelector(state);
  const discussions = discussionsSelector(state);

  let discussion = (room !== null && room.choosedDiscussionId !== null) ?
    discussionByIdSelector(room.choosedDiscussionId, discussions) :
    null;

  if (discussion === undefined) discussion = null;

  return {
    room,
    discussion
  };
}

const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
      closeModal: () => {
        return dispatch(changeChoosedDiscussion(null));
      },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ModalView);
