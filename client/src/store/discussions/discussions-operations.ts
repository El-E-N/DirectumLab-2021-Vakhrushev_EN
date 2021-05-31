import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import * as voteApi from '../../api/vote-api';
import {updateDiscussions} from './discussions-action-creators';
import {ICard, IDiscussion, IVote} from '../types';
import { translateDtoCardIntoCard } from '../card';
import { IDiscussionDto } from '../../api/api-utils';
import {updateVote as updateStoreVote} from './discussions-action-creators';
import {addCurrentDiscussionId} from '../room/room-action-creators';

export const translateDtoDiscussionIntoDiscussion = (discussionDto: IDiscussionDto) => {
  const allVote: { [key: string]: IVote | null } = {};
  const {voteList} = discussionDto;
  for (let i = 0; i < voteList.length; i++) {
    const playerId = voteList[i].playerId;
    const translatedCard = voteList[i].card && translateDtoCardIntoCard(voteList[i].card!);
    const card: ICard | null = translatedCard && voteList[i].card && {
      id: voteList[i].card!.id,
      value: translatedCard.value
    };
    allVote[playerId] = {id: voteList[i].id, card};
  }
  const discussion: IDiscussion = {
    id: discussionDto.id,
    name: discussionDto.name,
    average: null,
    voteArray: allVote,
    players: null
  };
  return discussion;
};

export const loadingDiscussions = (roomId: string): any => {
  return async (dispatch: Dispatch) => {
    const discussionsDto = await discussionApi.getDiscussionsByRoomIdRequest(roomId);
    const discussions: Array<IDiscussion> = discussionsDto.map((discussionDto) => {
      return translateDtoDiscussionIntoDiscussion(discussionDto);
    });
    dispatch(addCurrentDiscussionId(discussions[discussions.length - 1].id));
    return dispatch(updateDiscussions(discussions));
  }
}

export const updateVote = (voteId: string, cardId: string): any => {
  return async (dispatch: Dispatch) => {
    const voteDto = await voteApi.changeCardRequest(voteId, cardId);
    const translatedCard = voteDto.card && translateDtoCardIntoCard(voteDto.card);
    const card: ICard | null = voteDto.card && translatedCard && {
      id: voteDto.card.id,
      value: translatedCard.value
    };
    return dispatch(updateStoreVote(
      voteDto.discussionId,
      voteDto.playerId,
      {id: voteDto.id, card}
    ));
  };
};

export const createVote = (
  roomId: string,
  playerId: string,
  discussionId: string,
  ): any => {
  return async (dispatch: Dispatch) => {
    const voteDto = await voteApi.createVoteRequest(roomId, playerId, discussionId);
    const translatedCard = voteDto.card && translateDtoCardIntoCard(voteDto.card);
    const card: ICard | null = voteDto.card && translatedCard && {
      id: voteDto.card.id,
      value: translatedCard.value
    };
    return dispatch(updateStoreVote(
      voteDto.discussionId, 
      voteDto.playerId,
      {id: voteDto.id, card}
    ));
  };
};
