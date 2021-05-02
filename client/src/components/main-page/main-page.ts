import {IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView, {IMatchParams} from './main-page-view';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState, ownProps: IMatchParams) => {
  const room = state.rooms.find((r) => r.id === ownProps.id);
  // eslint-disable-next-line no-console
  console.log(ownProps.id);
  // eslint-disable-next-line no-console
  console.log(state.rooms);
  return {
    room,
    user: state.user,
    stories: state.stories,
  };
};

/* const mapDispatchToProps = (dispatch: Dispatch) => {
  return {
    vote: (roomId: string, value: string) => dispatch(vote(roomId, value)),
    removeStory: (id: string) => dispatch(removeStory(id)),
  };
};*/

export default compose<React.ComponentClass<IMain>>(connect(mapStateToProps), withRouter)(MainPageView);
