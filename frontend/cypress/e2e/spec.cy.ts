describe('CarCore', () => {
  it('Should search for Make and find a Model', () => {
    cy.visit('/')

    cy.get('select').select('BMW');

    cy.get('button').contains('Suchen').click();

    cy.get('table.table tbody tr')
      .contains('td', 'M3')
      .should('be.visible');
  })

  it('Should not be able to search because no Make is selected', () => {
    cy.visit('/')
    cy.get('button').should('be.disabled');
  })


  it('Table should not exist when visiting the page initially', () => {
    cy.visit('/')
    cy.get('table').should('not.exist')
  })

})
