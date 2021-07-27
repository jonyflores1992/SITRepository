import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchProduccion } from './components/FetchProduccion';
import { AddProduccion } from './components/AddProduccion';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/fetchproduccion' component={FetchProduccion} />
    <Route path='/addProduccion' component={AddProduccion} />
    <Route path='/TrProduccions/edit/:empid' component={AddProduccion} />
</Layout>;