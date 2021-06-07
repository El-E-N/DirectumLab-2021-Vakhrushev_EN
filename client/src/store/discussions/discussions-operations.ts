import {Dispatch} from 'redux';
import * as discussionApi from '../../api/discussion-api';
import * as voteApi from '../../api/vote-api';
import {updateDiscussions} from './discussions-action-creators';
import {ICard, IDiscussion, IPlayer, IVote} from '../types';
import { translateDtoCardIntoCard } from '../card';
import { IDiscussionDto } from '../../api/api-utils';
import {updateVote as updateStoreVote} from './discussions-action-creators';
import {addCurrentDiscussionId} from '../room/room-action-creators';

const getAvg = (voteList: {[key: string]: IVote | null}) => {
  let count = 0;
  let sum = 0;
  const cardValues = ['0', '0.5', '1', '2', '3', '5', '8', '13', '20','40', '100']
  for (const i in voteList) {
    const vote = voteList[i];
    if (vote && vote.card && cardValues.indexOf(String(vote.card.value)) !== -1) {
      sum += parseFloat(vote.card.value);
      count++;
    }
  }
  return count !== 0 ? Math.round(sum / count * 100) / 100 : 0;
};

export const translateDtoDiscussionIntoDiscussion = (discussionDto: IDiscussionDto, players: Array<IPlayer>) => {
  const allVote: { [key: string]: IVote | null } = {};
  const playerList: Array<IPlayer> = [];
  const {voteList} = discussionDto;
  for (let i = 0; i < voteList.length; i++) {
    const playerId = voteList[i].playerId;
    const translatedCard = voteList[i].card && translateDtoCardIntoCard(voteList[i].card!);
    const card: ICard | null = translatedCard && voteList[i].card && {
      id: voteList[i].card!.id,
      value: translatedCard.value
    };
    allVote[playerId] = {id: voteList[i].id, card};
    const player = players.find((player) => player.id === playerId);
    if (player !== undefined) playerList.push(player);
  }
  const discussion: IDiscussion = {
    id: discussionDto.id,
    name: discussionDto.name,
    average: getAvg(allVote),
    voteArray: allVote,
    players: playerList,
    startAt: discussionDto.startAt,
    endAt: discussionDto.endAt
  };
  return discussion;
};

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
  roomHash: string,
  playerId: string,
  discussionId: string,
  ): any => {
  return async (dispatch: Dispatch) => {
    const voteDto = await voteApi.createVoteRequest(roomHash, playerId, discussionId);
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
