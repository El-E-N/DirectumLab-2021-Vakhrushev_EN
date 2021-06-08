import {baseUrl, options, IVoteDto} from './api-utils';

const voteApi = `${baseUrl}/vote`;

export const createVoteRequest = async (
  roomHash: string,
  playerId: string,
  discussionId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
    `${voteApi}/create`,
    {...options.POST,
    body: JSON.stringify({
      roomHash,
      playerId,
      discussionId
    })}
  );
  return response.json();
};

export const changeCardRequest = async (
  voteId: string,
  cardId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
    `${voteApi}/changeCard`,
    {...options.POST,
    body: JSON.stringify({
      voteId,
      cardId
    })}
  );
  return response.json();
};

export const deleteVoteRequest = async (
  voteId: string
) => {
  await fetch(
    `${voteApi}/delete`,
    {...options.POST,
    body: JSON.stringify(voteId)}
  );
};
