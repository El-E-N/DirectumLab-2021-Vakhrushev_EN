import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import {updateDiscussions} from './discussions-action-creators';
import {IDiscussion} from '../types';
import {translateDtoDiscussionIntoDiscussion} from '../discussion/discussion-operations';

export const loadingDiscussions = (roomId: string): any => {
  return async (dispatch: Dispatch) => {
    const discussionsDto = await discussionApi.getDiscussionsByRoomIdRequest(roomId);
    const discussions: Array<IDiscussion> = discussionsDto.map((discussionDto) => {
      return translateDtoDiscussionIntoDiscussion(discussionDto);
    });
    dispatch(updateDiscussions(discussions));
  }
}
