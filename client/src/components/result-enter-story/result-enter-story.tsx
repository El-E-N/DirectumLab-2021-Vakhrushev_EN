import * as React from 'react';
import Header from '../header/header';
import Room from '../room/room';
import Footer from '../footer/footer';

const ResultEnterStory: React.FunctionComponent = () => {
  return <React.Fragment>
    <Header addUser={true}/>
    <Room isPlanning={false} addEnterStory={true}/>
    <Footer />
  </React.Fragment>;
};

export default ResultEnterStory;
