'use strict';
/*
 'use strict' is not required but helpful for turning syntactical errors into true errors in the program flow
 https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
*/

/*
 Modules make it possible to import JavaScript files into your application.  Modules are imported
 using 'require' statements that give you a reference to the module.

  It is a good idea to list the modules that your application depends on in the package.json in the project root
 */
var util = require('util');

/*
 Once you 'require' a module you can reference the things that it exports.  These are defined in module.exports.

 For a controller in a127 (which this is) you should export the functions referenced in your Swagger document by name.

 Either:
  - The HTTP Verb of the corresponding operation (get, put, post, delete, etc)
  - Or the operationId associated with the operation in your Swagger document

  In the starter/skeleton project the 'get' operation on the '/hello' path has an operationId named 'hello'.  Here,
  we specify that in the exports of this module that 'hello' maps to the function named 'hello'
 */
module.exports = {
  bmcById: bmcById,
  bmcByIdAddItem: bmcByIdAddItem
};


function bmcByIdAddItem(req, res) {
  console.log('test');
  var obj = {categoryId: 9, title: 'z', description: 'abc', order: 6, created: '2018-01-01 09:04'};
  res.json(obj);
}

/*
  Functions in a127 controllers used for operations should take two parameters:

  Param 1: a handle to the request object
  Param 2: a handle to the response object
 */
function bmcById(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  var canvasData = {
    designedFor: "",
    keyPartners: {
      id: 1,
      name: 'Key Partners',
      description: 'Key Partners are the relationships that you have with other business, governmental, or non-consumer entities that help your business model work. These can be the relationships that your company has with your suppliers, your manufacturers, business partners, etc. These partnerships that you will undoubtedly create will be forces that help your business succeed in areas that would be inefficient for you to do yourself.',
      singularName: 'Key Partner',
      items: []
    },
    channels: {
      id: 2,
      name: 'Channels',
      description: '',
      singularName: 'Channel',
      items: []
    },
    costStructure: {
      id: 3,
      name: 'Cost Structures',
      description: '',
      singularName: 'Cost Structure',
      items: []
    },
    customerRelationships: {
      id: 4,
      name: 'Customer Relationships',
      description: '',
      singularName: 'Customer Relationship',
      items: []
    },
    customerSegments:	{
      id: 5,
      name: 'Customer Segments',
      description: '',
      singularName: 'Customer Segment',
      items: []
    },
    keyActivities: {
      id: 6,
      name: 'Key Activities',
      description: '',
      singularName: 'Key Activity',
      items: []
    },
    keyResources: {
      id: 7,
      name: 'Key Resources',
      description: '',
      singularName: 'Key Resources',
      items: []
    },
    revenueStreams: {
      id: 8,
      name: 'Revenue Streams',
      description: '',
      singularName: 'Revenue Stream',
      items: []
    },
    valuePropositions: {
      id: 9,
      name: 'Value Propositions',
      description: '',
      singularName: 'Value Proposition',
      items: []
    } 
  };

  var entities = [
      {id: 1, categoryId: 1, title: 'a', description: 'abc', order: 4, created: '2018-01-06 10:14'}
    , {id: 2, categoryId: 1, title: 'b', description: 'abc', order: 3, created: '2018-01-05 11:24'}
    , {id: 3, categoryId: 2, title: 'c', description: 'abc', order: 5, created: '2018-01-02 14:34'}
    , {id: 4, categoryId: 3, title: 'd', description: 'abc', order: 1, created: '2018-01-03 05:44'}
    , {id: 5, categoryId: 4, title: 'e', description: 'abc', order: 2, created: '2018-01-04 23:54'}
    , {id: 6, categoryId: 5, title: 'f', description: 'abc', order: 6, created: '2018-01-01 09:04'}
    , {id: 7, categoryId: 6, title: 'g', description: 'abc', order: 6, created: '2018-01-01 09:04'}
    , {id: 8, categoryId: 7, title: 'h', description: 'abc', order: 6, created: '2018-01-01 09:04'}
    , {id: 9, categoryId: 7, title: 'i', description: 'abc', order: 6, created: '2018-01-01 09:04'}
    , {id: 10, categoryId: 8, title: 'j', description: 'abc', order: 6, created: '2018-01-01 09:04'}
    , {id: 11, categoryId: 9, title: 'k', description: 'abc', order: 6, created: '2018-01-01 09:04'}
  ];

  canvasData.designedFor = 'Kalle Kula AB';
  canvasData.id = 1;
  canvasData.name = 'Test Canvas';

  // entities to models
  canvasData.channels.items.push(entities[0]);
  canvasData.channels.items.push(entities[1]);

  canvasData.costStructure.items.push(entities[2]);

  canvasData.customerRelationships.items.push(entities[3]);
  
  canvasData.customerSegments.items.push(entities[4]);

  canvasData.keyActivities.items.push(entities[5]);

  canvasData.keyPartners.items.push(entities[6]);

  canvasData.keyResources.items.push(entities[7]);
  canvasData.keyResources.items.push(entities[8]);

  canvasData.revenueStreams.items.push(entities[9]);

  canvasData.valuePropositions.items.push(entities[10]);

  // this sends back a JSON response which is a single string
  res.json(canvasData);
}
