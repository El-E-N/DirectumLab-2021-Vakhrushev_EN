export const baseUrl = 'http://localhost:3030/api';

export const options = {
  GET: {
    method: 'GET',
    headers: {'Content-Type': 'application/json'}
  },
  POST: {
    method: 'POST',
    headers: {'Content-Type': 'application/json;charset=utf-8'}
  }
};

export interface IRoomDto {
  id: string;
  hash: string;
  name: string;
  players: Array<IPlayerDto>;
  allPlayers: Array<IPlayerDto>;
  hostId: string;
  creatorId: string;
  cards: Array<ICardDto>;
  discussions: Array<IDiscussionDto>;
}

export interface IPlayerDto {
  id: string;
  name: string;
}

export interface IDiscussionDto {
  id: string;
  name: string;
  voteList: Array<IVoteDto>;
  startAt: string | null;
  endAt: string | null;
}

export interface IVoteDto {
  id: string;
  playerId: string;
  discussionId: string;
  card: ICardDto | null;
}

export interface ICardDto {
  id: string;
  value: string | null;
  name: string;
}
