import {IRootState} from '../store/types';

export const mockState: IRootState = {
  rooms: [
    {
      id: '777',
      name: 'First Room',
      cards: ['0', '0.5', '1', '2', '3', '5', '8', '13', '20', '40', '100', '?', '∞', 'coffee'],
      selectedCard: null,
      ownerId: 'test_user',
      usersId: ['test_user'],
    },
  ],
  stories: [
    {
      id: '1',
      name: 'The first story',
      average: 8,
      votes: {
        player1: '8',
        player2: '8',
      },
    },
    {
      id: '2',
      name: 'The second story',
      average: 16,
      votes: {
        player1: '16',
        player2: '16',
      },
    },
  ],
  user: {
    id: 'test_user',
    name: 'Tester',
  },
  users: [
    {
      id: 'test_user',
      name: 'Tester',
    },
  ],
};
