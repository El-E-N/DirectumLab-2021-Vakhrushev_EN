import {baseUrl, post, IVoteDto} from './api-utils';

const voteApi = `${baseUrl}/vote`;

export const createVoteRequest = async (
  roomHash: string,
  playerId: string,
  discussionId: string,
): Promise<IVoteDto> => {
  const response = await fetch(
    `${voteApi}/create`,
    {...post(),
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
    {...post(),
    body: JSON.stringify({
      voteId,
      cardId
    })}
  );
  return response.json();
};

export const deleteVoteRequest = async (
  voteId: string
): Promise<{token: string}> => {
  const response = await fetch(
    `${voteApi}/delete`,
    {...post(),
    body: JSON.stringify(voteId)}
  );
  return response.json();
};
