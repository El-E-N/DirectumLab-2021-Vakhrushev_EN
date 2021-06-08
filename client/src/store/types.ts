export interface IPlayer {
  id: string;
  name: string;
}

export interface IRoom {
  id: string;
  hash: string;
  name: string;
  cards: Array<ICard>;
  hostId: string;
  creatorId: string;
  currentDiscussionId: string | null;
  choosedDiscussionId: string | null;
  players: Array<IPlayer>;
}

export interface IDiscussion {
  id: string;
  name: string;
  average: number;
  players: Array<IPlayer>;
  voteArray: { [key: string]: IVote | null }; // key - userId, value - vote
  startAt: string | null;
  endAt: string | null;
}

export interface IVote {
  id: string;
  card: ICard | null;
}

export interface ICard {
  id: string;
  value: string;
}

export interface IRootState {
  room: IRoom | null;
  discussions: Array<IDiscussion>;
  user: IPlayer | null;
}
