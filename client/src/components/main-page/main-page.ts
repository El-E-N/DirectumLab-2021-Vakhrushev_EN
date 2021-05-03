import {IRootState} from '../../store/types';
import {compose} from 'redux';
import * as React from 'react';
import {withRouter} from 'react-router-dom';
import {connect} from 'react-redux';
import MainPageView, {IMainPageProps} from './main-page-view';

interface IMain {
  onShowModal(): void;
}

const mapStateToProps = (state: IRootState, ownProps: IMainPageProps) => {
  const roomId = ownProps.match.params.id;
  const room = state.rooms.find((r) => r.id === roomId);
  return {
    room,
    user: state.user,
    stories: state.stories,
  };
};

export default compose<React.ComponentClass<IMain>>(withRouter, connect(mapStateToProps))(MainPageView);
