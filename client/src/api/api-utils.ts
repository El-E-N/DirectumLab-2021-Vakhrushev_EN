export const baseUrl = 'http://localhost:3030/api';

export const options = {
  GET: {
    method: 'GET',
    headers: {'Content-Type': 'application/json'}
  }
};

export interface IRoomDto {
  id: string;
  hash: string;
  name: string;
  players: Array<IPlayerDto>;
  hostId: string;
  creatorId: string;
}

export interface IPlayerDto {
  id: string;
  name: string;
}

export interface IDiscussionDto {
  id: string;
  name: string;
  voteList: Array<IVoteDto>;
}

export interface IVoteDto {
  id: string;
  playerId: string;
  card: ICardDto | null;
}

export interface ICardDto {
  id: string;
  value: string | null;
  name: string;
}
