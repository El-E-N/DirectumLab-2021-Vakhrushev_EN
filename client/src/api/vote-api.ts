import {IVoteDto} from './types';
import {baseUrl, options} from './api';

export const createVoteRequest = async (
    cardId: string,
    roomId: string,
    playerId: string,
    discussionId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
      `${baseUrl}/vote/create?cardId=${cardId}&roomId=${roomId}&playerId=${playerId}&discussionId=${discussionId}`,
      options.GET);
  return response.json();
};

export const changeCardRequest = async (
    voteId: string,
    cardId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
      `${baseUrl}/vote/changeCard?voteId=${voteId}&cardId=${cardId}`,
      options.GET);
  return response.json();
};
