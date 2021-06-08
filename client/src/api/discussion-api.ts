import {IDiscussionDto, baseUrl, post} from './api-utils';

const discussionUrl = `${baseUrl}/discussion`;

export const createDiscussionRequest = async (
  roomHash: string,
  name: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
    `${discussionUrl}/create`,
    {...post(),
    body: JSON.stringify({
      roomHash,
      name
    })}
  );
  return response.json();
};

export const deleteDiscussionRequest = async (
  discussionId: string
): Promise<{token: string}> => {
  const response = await fetch(
    `${discussionUrl}/delete`,
    {...post(),
    body: JSON.stringify(discussionId)}
  );
  return response.json();
};

export const closeDiscussionRequest = async (
  discussionId: string,
): Promise<IDiscussionDto> => {
  const response = await fetch(
    `${discussionUrl}/close`,
    {...post(),
    body: JSON.stringify(discussionId)}
  );
  return response.json();
};

export const setDiscussionNameRequest = async (
  discussionId: string,
  name: string
): Promise<IDiscussionDto> => {
  const response = await fetch(
    `${discussionUrl}/setName`,
    {...post(),
    body: JSON.stringify({
      discussionId,
      name
    })}
  );
  return response.json();
};
